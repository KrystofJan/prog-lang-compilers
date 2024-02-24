# Programming Languages and Compilers
## About
A Subject that will give me a look behind the curtain on how compilers and interpreters work

## Tasks

### Task1 - Interpreter of Arithmetic Expressions
Implement an interpreter of arithmetic expressions. These expressions contain +, -, *, / operators (with common priorities and left associativity) and parentheses.
To simplify the task, consider we have only binary operators. There are no unary operators in our language. Moreover, we can use only positive integers in our expressions. 

#### Input specifications
The first line of the input contains a number N. It defines the number of expressions your program should evaluate. These expressions are on next N lines. Each line contains exactly one expression. 

#### Output specification
For each expression write one line containing the result – the computed value of the expression. If there is any error in the input, write text ERROR instead. 

#### Example
- input
``` bash
2
2 *  (3+5)
15 - 2 ** 7
```
- output
``` bash
16
ERROR
```