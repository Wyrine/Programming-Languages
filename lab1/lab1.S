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

.global Push
Push:
	//don't care about return value aka rax
	//rdi = s, edi = val
	//s->data
	mov rdx, [rdi]
	//s->data --
	sub rdx, 4 // (s->data) += 4 bytes
	//*(s->data) = esi
	mov [rdx], esi
	mov [rdi], rdx
	ret

