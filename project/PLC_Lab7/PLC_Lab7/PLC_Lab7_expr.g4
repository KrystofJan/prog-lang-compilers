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
	  values operation?
	| assignment
	| unary
    | '(' expr ')';

unary:
	NEG_OP expr | UN_MIN expr;


assignment: 
	ID ASSIGN UN_MIN? expr;


values: 
	  ID 
  	| INT 
  	| FLOAT 
  	| BOOL 
  	| STRING ;

operation: 
	  operator expr;

operator: 
	  BIN_AR_ADD 
	| BIN_AR_MUL 
	| CMP 
	| REL 
	| LOG_OR 
	| LOG_AND ;
    

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
