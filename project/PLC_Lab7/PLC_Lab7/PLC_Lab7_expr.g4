grammar PLC_Lab7_expr;

/** The start rule; begin parsing here. */
prog: 
	(stat)+;

stat: 	
      ';'                                           # sem
	| dtype ID (',' ID)* ';'                        # declaration
	| expr ';'                                      # expression
    | 'read' ID (',' ID)*  ';'                      # read
	| 'write' expr (',' expr)*  ';'                 # write
	| '{' stat (stat)* '}'                          # scope
	| 'if' cond stat ('else' stat)?                 # if
	| 'while' cond stat                             # whileCyc
	| 'for' '(' expr  ';' cond ';' expr ')' stat    # forCyc
    ;

dtype: 	
          INT_KW    # int
        | FLOAT_KW  # float
        | BOOL_KW   # bool
        | STRING_KW # string
        ;
	
cond:
	   '(' expr ')' # condWrapped
	 | expr         # condClean
	 ;

expr: 	  
	  values operation?         # exprWithValue
	| assignment                # assign
	| unary                     # unar
    | '(' expr ')'              # exprWrapped
    ;
    
unary:
	NEG_OP expr | UN_MIN expr;

assignment: 
	  ID ASSIGN values (',' ASSIGN values)*;

values: 
	  ID 
  	| INT 
  	| FLOAT 
  	| BOOL 
  	| STRING ;

operation: 
	  operator expr;

operator: 
	  BIN_AR_ADD    # binAdd
	| BIN_AR_MUL    # binMul
	| CMP           # cmp
	| REL           # rel
	| LOG_OR        # logOr
	| LOG_AND       # logAnd
	;     
    
// types
INT_KW : 'int';
FLOAT_KW : 'float';
BOOL_KW : 'bool';
STRING_KW: 'string';



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
BIN_AR_MUL: 	'*' | '/' | '%';
BIN_AR_ADD: 	'+' | '-' | '.';
LOG_OR:     	'||';
LOG_AND: 	    '&&';
CMP: 		    '==' | '!=';
REL: 		    '<' | '>';

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
