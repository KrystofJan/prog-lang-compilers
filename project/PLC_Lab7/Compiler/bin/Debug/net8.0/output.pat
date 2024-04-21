push I 3
push I 4
lt I
fjmp I 0
push S "condition was true"
print I 1
jmp I 1
label I 0
push S "condition was false"
print I 1
label I 1
push B True
fjmp I 2
push S "inside"
print I 1
push S "second"
print I 1
push S "if"
print I 1
jmp I 3
label I 2
label I 3
push I 0
save I a
push I 0
save I b
label I 4
load I a
push I 10
lt I
fjmp I 5
push S "a="
load I a
print I 2
load I a
push I 1
add I
save I a
load I a
pop I
jmp I 4
label I 5
push I 0
save I a
load I a
pop I
read I INT
save I b
label I 6
load I a
load I b
lt I
fjmp I 7
push S "a="
load I a
push S ", b="
load I b
print I 4
load I a
push I 1
add I
save I a
load I a
pop I
jmp I 6
label I 7
