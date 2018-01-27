.intel_syntax noprefix

.section .text
.global FibRecur
FibRecur:
	cmp di, 1
	//if di <= 1
	jle 1f
	//else
	//n - 1
	dec di
	//push n on the stack so we don't lose it's value
	push di
	//FibRecur(n-1)
	call FibRecur
	//pop out n again
	pop di
	//push the return value on the stack
	push rax
	//n - 2
	dec di
	call FibRecur
	//n = previous return value
	pop rdi
	//add the two
	add rax, rdi
	ret
1:// base case
	mov rax, 1
	ret

.global FibTail
FibTail:
	mov rsi, 1 //rv1
	mov rdx, 1 //rv2
1:
	cmp di, 1
	//if n < 1
	jl 1f
	//n - 1
	dec di
	mov rcx, rdx
	add rdx, rsi
	//rv2 = tmp
	mov rsi, rcx
	jmp 1b
1:
	mov rax, rsi
	ret

.global Pop
Pop:
	mov rax, [rdi]
	mov rax, [rax]
	add DWORD PTR[rdi], 4
	ret



.global Push
Push:
	//rdi = s, edi = val
	//s->data
	mov rdx, [rdi]
	//s->data --
	sub rdx, 4 
	//*(s->data) = esi
	mov [rdx], esi
	//Update s to reflect changes
	mov [rdi], rdx
	ret

