//Kirolos Shahat
//Lab1 -- CS365
.intel_syntax noprefix

.section .rodata
out: .asciz "%d\n"

.section .text

// Fibonacci Functions
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


// Stack Functions
.global Push
Push:
	//rdi = s, esi = val
	//s->data
	mov rdx, [rdi]
	//s->data --
	sub rdx, 4 
	//*(s->data) = esi
	mov [rdx], esi
	//Update s to reflect changes
	mov [rdi], rdx
	ret

.global Pop
Pop:
	//rax = s->data
	mov rax, [rdi]
	// rax = *(s->data)
	mov rax, [rax]
	//s->data += 4 bytes
	add DWORD PTR[rdi], 4
	ret


//Tree Functions
.global Insert
Insert:
	//rdi = root, esi = value
	cmp rdi, 0
	jne 1f
	//root == NULL
	push rsi
	//set up malloc(sizeof struct is 24)
	mov rdi, 24
	//call malloc
	call malloc@plt
	//get the value parameter back
	pop rsi
	//put esi into root->value
	mov [rax], esi
	//set up block's left and right to be NULL
	mov QWORD PTR[rax+8], 0
	mov QWORD PTR[rax+16], 0
	//make root = rax so the reference and the return are same
	mov rdi, rax
	ret

	
1://root is not NULL if we're here
	//ecx is now root->value
	mov rcx, [rdi]
	//compare root->value and value
	cmp ecx, esi
	jge 2f

	//root->value < value
	//rcx is root->right
	mov rcx, [rdi+16]
	//check if root->right is null
	cmp rcx, 0
	//push rdi because it will be altered
	push rdi
	//rdi = root->right
	mov rdi, rcx
	//if not go to 3f
	jne 3f
	//otherwise, store value because it might be altered
	push rsi
	//set up malloc(sizeof struct is 24)
	mov rdi, 24
	//call malloc
	call malloc@plt
	//get back stored root and value
	pop rsi
	pop rdi
	//setting the new block's value as our value
	mov [rax], rsi
	//set up block's left and right to be NULL
	mov QWORD PTR[rax+8], 0
	mov QWORD PTR[rax+16], 0
	//updating right pointer to be the new block
	mov [rdi + 16], rax
	ret

2://root->value >= value
	//rcx is root->left
	mov rcx, [rdi+8]
	//check if root->left is null
	cmp rcx, 0
	//store root because it will be altered
	push rdi
	//root = root->left
	mov rdi, rcx
	jne 3f
	//otherwise, store value because it might be altered
	push rsi
	//set up malloc(sizeof struct is 24)
	mov rdi, 24
	//call malloc
	call malloc@plt
	//get back stored root and value
	pop rsi
	pop rdi
	//setting the new block's value as our value
	mov [rax], rsi
	//set up block's left and right to be NULL
	mov QWORD PTR[rax+8], 0
	mov QWORD PTR[rax+16], 0
	//updating left pointer from root
	mov [rdi + 8], rax
	ret

3://continuing down the trail of stack frames from either path
	//root is already the pointer it needs to be
	call Insert
	//get back original root
	pop rdi
	ret

.global Search
Search:
	//rdi = root, esi = search_value
	// is root == NULL?
	cmp rdi, 0
	//if so, go to 1f
	je 1f
	//ecx is now root->value
	mov ecx, [rdi]
	//is root->value == search_value?
	cmp ecx, esi
	//if so, go to 1f
	je 1f
	//if root->value < search_value go to 2f
	jl 2f
	//else
	push rdi
	//rdi = root->left
	mov rdi, [rdi+8]
	//search down left path
	call Search
	//get back root
	pop rdi
	ret

1:
	//root is either NULL or is the value so thus
	//return root
	mov rax, rdi
	ret
2:
	//push root
	push rdi
	//root = root->right
	mov rdi, [rdi+16]
	//search right branch
	call Search
	//get back original root
	pop rdi
	ret
	
//inorder traversal of tree and print values
.global PrintTree
PrintTree:
	//rdi = root
	//rsi is root->left
	mov rsi, [rdi+8]
	//check to see that it's not NULL
	cmp rsi, 0
	je	1f
	//root->left is not null
	//saving root
	push rdi
	//root = root->left
	mov rdi, rsi
	//call recursive func
	call PrintTree
	pop rdi

1://printf part of the statement
	//save root
	push rdi
	//rsi = root->value
	mov rsi, [rdi] 
	//prep printf
	lea	rdi, [rip+out]
	mov rax, 0
	call printf@plt
	pop rdi

	//PrintTree(root->right);
	mov rsi, [rdi+16]
	//check if root->right is null
	cmp rsi, 0
	//if it is go to 2f
	je 2f
	push rdi
	//root = root->right
	mov rdi, rsi
	//go right
	call PrintTree
	pop rdi
2:
	//done with current branch
	ret
