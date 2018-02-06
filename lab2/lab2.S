.intel_syntax noprefix

/*
Kirolos Shahat
Lab 2 -- CS 365
*/

.section .rodata
//empty string label
empt: .asciz ""

.section .text

//destructor
//~mystring()
.global _ZN8mystringD1Ev
_ZN8mystringD1Ev:
	mov	QWORD PTR[rdi+8], 0
	//compare the pointer to see if it's null
	cmp QWORD PTR[rdi], 0
	//if it is null
	je 1f
	//otherwise free
	mov rdi, [rdi]
	//calling free because of malloc call 
	//used strdup
	call free@plt
1:
	//set mstring to be NULL
	mov QWORD PTR[rdi], 0
	ret

//mystring()
.global _ZN8mystringC1Ev
_ZN8mystringC1Ev:
	lea rsi, [rip+empt]
	//continue to one argument constructor

//mystring(const char *s)
.global _ZN8mystringC1EPKc
_ZN8mystringC1EPKc:
	push rdi
	//move the new string into rdi
	mov rdi, rsi
	
	//call strdup
	call strdup@plt
	
	//get back the previous parameters
	pop rdi

	//mString = strdup
	mov [rdi], rax
	
	//push the struct back on the stack
	push rdi
	//move the new string to the first parameter
	mov rdi, rax
	
	//call strlen
	call strlen@plt
	
	//get back the rdi
	pop rdi
	//mStringLength = eax
	mov [rdi+8], eax
	ret

//mystring(const mystring &rhs)
.global _ZN8mystringC1ERKS_
_ZN8mystringC1ERKS_:
	push rdi
	push rsi
	//this* doesn't change
	//but rsi now is the char*
	mov rsi, [rsi]
	
	//call char* constructor
	call _ZN8mystringC1EPKc@plt

	//pop out the old values
	pop rsi
	pop rdi
	ret

//mystring &operator=(const char *s)
.global _ZN8mystringaSEPKc
_ZN8mystringaSEPKc:
	//check the pointer to see if it's null
	cmp QWORD PTR[rdi], 0
	//if it is null go to 1f
	je 1f
	//push this*, char* on stack
	push rdi
	push rsi
	//rdi = rdi->mString
	mov rdi, [rdi]
	//call free
	call free@plt
	//get back the previous values
	pop rsi
	pop rdi
1:
	push rdi
	//call one argument constructor
	call _ZN8mystringC1EPKc@plt
	//make this* the return value
	pop rax
	//mov rax, rdi
	ret

//mystring &operator=(const mystring &&rhs)
.global _ZN8mystringaSEOKS_
_ZN8mystringaSEOKS_:
	//see if this->mString is null
	cmp QWORD PTR[rdi], 0
	//if it is then go to 1f
	je 1f
	//otherwise free what is currently there
	push rdi
	push rsi
	//rdi = this->mString
	mov rdi, [rdi]
	//call free
	call free@plt
	//get back old this and rhs
	pop rsi
	pop rdi
1:
	//rsi = *rhs
	mov rcx, [rsi]
	//rcx = rcx->mString
	mov rcx, [rcx]

	//this->mString = (*rhs)->mString
	mov [rdi], rcx
	
	//rcx = *rsi
	mov rcx, [rsi]
	mov ecx, [rcx+8]
	//put the size into this->mStringLength
	mov [rdi+8], ecx
	//rax = this
	mov rax, rdi
	ret

//int length() const
.global _ZNK8mystring6lengthEv
_ZNK8mystring6lengthEv:
	mov eax, [rdi+8]
	ret

//int find(const mystring &rhs) const
.global _ZNK8mystring4findERKS_
_ZNK8mystring4findERKS_:
	mov rsi, [rsi]

//int find(const char *s) const
.global _ZNK8mystring4findEPKc
_ZNK8mystring4findEPKc:
	//get the string for the class
	push rdi
	push rsi

	mov rdi, [rdi]

	//get address of substring from strstr
	call strstr@plt

	pop rsi
	pop rdi
	//if strstr returns NULL then the substring is not in mString
	cmp rax, 0
	//therefore go to 1f because not found
	je 1f
	//index = substring_address - initial_address
	mov rdi, [rdi]
	sub rax, rdi
	//go to 2f with the found index
	jmp 2f
1:	//not found
	mov rax, -1
2:	// return whatever rax is
	ret

//const char *c_str() const
.global _ZNK8mystring5c_strEv
_ZNK8mystring5c_strEv:
	//return this->mString
	mov rax, [rdi]
	ret

//friend ostream &operator<<(...)
.global _ZlsRSoRK8mystring
_ZlsRSoRK8mystring:
	//push out
	push rdi
	//parameter 2 is now mString
	mov rsi, [rsi]
	//call out.operator<<(const char*)
	call _ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc@plt
	//pop the out into rax so that we can chain
	pop rax
	ret

