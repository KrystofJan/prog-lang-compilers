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
	| for ;

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
	'if' expr stat ('else' stat)? ;

while: 	
	'while' expr stat;

for: 
    'for' '(' expr  ';' expr ';' expr ')' stat ;

unary:
	NEG_OP expr | UN_MIN expr;

expr: 	  
      assignment; 

assignment: 
	  ID ASSIGN assignment  # assExpr
	| assignmentTail    #assTail
	;

assignmentTail: 
    tail
    | ternary;

ternary: 
    <assoc=right> ternaryTail '?' ternaryTail ':' ternaryTail    # mathTern
    | ternaryTail                          # tailTern
;
ternaryTail:
    tail
    | mathOr;

mathOr: 
    mathOr LOG_OR orTail    # orExpr
    | orTail                #tailOr
    ;

orTail:
    tail 
    | mathAnd;

mathAnd:
    mathAnd LOG_AND andTail # andExpr
    | andTail               # tailAnd
    ;

andTail: 
    tail
    | mathRel;
    
values: 
	  ID    # identity
  	| INT   # integerVal
  	| FLOAT # floatVal
  	| BOOL  # booleanVal
  	| STRING # stringVal
  	;

mathAdd: 
      mathAdd op=(ADD_OP | MIN_OP | CONCAT_OP) addTail  # addExpr
    | addTail                                           # tailAdd
    ;

addTail: 
    tail
    | mathMul
    ;

mathMul: 
    mathMul op=(	MUL_OP | DIV_OP | MOD_OP) mulTail   # mulExpr
    | mulTail                                           # tailMul
    ;

mulTail:
    tail;
    

mathCmp: 
    mathCmp op=(EQ | NEQ) compTail   # cmpExpr
    | compTail                      # cmpTail
    ;
    
compTail: 
    tail
    | mathRel
    ;

mathRel: 
    mathRel op=(CMP_LT | CMP_MT) relTail
    | relTail
    ;

relTail: 
    tail
    | mathAdd
    ;   

tail:       
    values          # mathValue
    | '(' expr ')'  # exprWrap
    | unary         # unar
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
