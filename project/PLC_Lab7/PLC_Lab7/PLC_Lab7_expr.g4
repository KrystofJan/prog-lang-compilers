grammar PLC_Lab7_expr;

/** The start rule; begin parsing here. */
prog: 
	(stat)+;

stat: 	
	  ';'
	| types ';'
	| expr ';'
	| read ';'
	| write ';'
	| statwrap
	| if
	| while
	| for;

types: 	
	dtype ID (',' ID)* ;
	
dtype: 	
	'int' | 'float' | 'bool' | 'string';

read: 	
	'read' ID (',' ID)* ;

write: 	
	'write' expr (',' expr)* ;

statwrap: 
	'{' stat (stat)* '}';

if: 	
	'if' cond stat ('else' stat)? ;

cond:
	   '(' expr ')'
	 | expr;


while: 	
	'while' cond stat;

for: 
    'for' '(' expr  ';' cond ';' expr ')' stat ;

expr: 	  
	  exprMath          # math
	| assignment        # ass
	| unary             # unar
    | '(' expr ')'      # exprWrap
    ; 

unary:
	NEG_OP expr | UN_MIN expr;

assignment: 
	ID ASSIGN UN_MIN? expr;

values: 
	  ID    # identity
  	| INT   # integerVal
  	| FLOAT # floatVal
  	| BOOL  # booleanVal
  	| STRING # stringVal
  	;

exprMath: 
      values                # mathValue
    | mathOp                # mathExpr
    ;

mathOp: 
      values op=(ADD_OP | MIN_OP | CONCAT_OP) expr  # mathAdd
    | values op=(	MUL_OP | DIV_OP | MOD_OP) expr  # mathMul
    | values op=(EQ | NEQ) expr                     # mathCmp
    | values op=(CMP_LT | CMP_MT) expr              # mathRel
    | values LOG_OR expr                            # mathOr
    | values LOG_AND expr                           # mathAnd
    ;
    

// matches
ID : [a-zA-Z][a-zA-Z0-9_]* ;        // match identifiers
INT : [1-9][0-9]*|'0' ;          // match integers
BOOL : 'true'|'false' ;          // match bool
FLOAT : [1-9][0-9]*'.'[0-9]* ;  // match float
STRING : '"'[a-zA-Z0-9_.+/*,'@&%=(!){[\]};<>: -]*'"' ; // match string
WS : [ \t\r\n]+ -> skip ;   // toss out whitespace

// operators
ASSIGN: 	    '=';
UN_MIN: 	    '-';
NEG_OP: 	    '!';
CMP_LT:         '<';
CMP_MT:         '>';
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


// symbols
//PLUS: 	    '+';
//CONCAT:     '.';
//EQ: 	    '=';
//EMP: 	    '&';
//MOD: 	    '%';
//MUL: 	    '*';
//MIN:        '-';
//CMP_LESS: 	'<';
//CMP_MORE: 	'>';
//PIPE: 	    '|';
//NEG: 	    '!';
//DIV:        '/';
