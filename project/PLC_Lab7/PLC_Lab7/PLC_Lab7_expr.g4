grammar PLC_Lab7_expr;

/** The start rule; begin parsing here. */
prog: 
	(stat)+;

stat: 	
	  ';'               # sem
	| decleration ';'   # decl
	| expr ';'          # exp
	| read ';'          # rd
	| write ';'         # wr
	| statwrap          # scoped
	| if                # ifstat
	| while             # whilecyc
	| for               # forcyc
	;

decleration: 	
	dtype ID (',' ID)* ;
	
dtype: 	
	'int'       # intDtype  
	| 'float'   # fltDtype
	| 'bool'    # bolDtype
	| 'string'  # strDtype 
    ;

read: 	
	'read' ID (',' ID)* ;

write: 	
	'write' expr (',' expr)* ;

statwrap: 
	'{' stat (stat)* '}';

if: 	
	'if' expr stat ('else' stat)? ;

while: 	
	'while' expr stat;

for: 
    'for' '(' expr  ';' expr ';' expr ')' stat ;

expr:
      primary (expr)*                                           # exprPrimary             
     | UN_MIN expr                                              # unaryMin
     | NEG_OP expr                                              # unaryNeg
     | expr op=(MUL_OP | DIV_OP | MOD_OP) expr                  # exprMul
     | expr op=(ADD_OP | MIN_OP | CONCAT_OP) expr               # exprAdd
     | expr op=(CMP_LT | CMP_GT) expr                           # exprRl
     | expr op=(EQ | NEQ) expr                                  # exprCmp
     | expr op=LOG_AND expr                                     # exprAnd
     | expr op=LOG_OR expr                                      # exprOr
     | <assoc = right> cond=expr op=QUES tb=expr COLON fb=expr  # exprTernar
     | <assoc = right> ID op=ASSIGN expr                        # exprAss
     ;

primary:
    '(' expr ')'    # primaryWrapped
    | values        # primaryValues
    ;   

values: 
  	INT         # integerVal
  	| FLOAT     # floatVal
  	| BOOL      # booleanVal
  	| STRING    # stringVal
	| ID        # identity
  	;    

// matches
ID : [a-zA-Z][a-zA-Z0-9_]* ;
INT : [1-9][0-9]*|'0' ;
BOOL : 'true'|'false' ;
FLOAT : [0-9]'.'[0-9]* | [1-9][0-9]*'.'[0-9]* ;
STRING : '"'[a-zA-Z0-9_.+/*,'@&%=(!){[\]};<>: -]*'"' ;
WS : [ \t\r\n]+ -> skip ;
COMMENT: '//' .*? '\n' -> skip;

// Symbols
ASSIGN: 	    '=';
UN_MIN: 	    '-';
NEG_OP: 	    '!';
CMP_LT:         '<';
CMP_GT:         '>';
ADD_OP:         '+';
MIN_OP:         '-';
CONCAT_OP:      '.';
MUL_OP: 	    '*';
DIV_OP:         '/';
MOD_OP:         '%';
LOG_OR:     	'||';
LOG_AND: 	    '&&';
EQ:             '==';
NEQ:            '!=';
QUES:           '?';
COLON:          ':';
