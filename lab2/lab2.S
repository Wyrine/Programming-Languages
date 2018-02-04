.intel_syntax noprefix

.section .rodata
empt: .asciz ""

.section .text

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
	//call _Zd1Pv@plt
	call free@plt
1:
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
	push rsi
	//move the new string into rdi
	mov rdi, rsi
	
	//call strdup
	call strdup@plt
	
	//get back the previous parameters
	pop rsi
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
	//copy constructor
	push rdi
	push rsi
	mov rdi, rsi

	call _ZN8mystringC1EPKc@plt

	pop rsi
	mov rsi, rdi
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
	//call one argument constructor
	call _ZN8mystringC1EPKc@plt
	//make this* the return value
	mov rax, rdi
	ret

//mystring &operator=(const mystring &&rhs)
.global _ZN8mystringaSEOKS_
_ZN8mystringaSEOKS_:
	cmp QWORD PTR[rdi], 0
	je 1f
	push rdi
	push rsi
	mov rdi, [rdi]
	call free@plt
	pop rsi
	pop rdi
1:
	mov rcx, [rsi]
	mov rcx, [rcx]
	mov QWORD PTR[rdi], rcx
	mov rcx, [rcx]
	mov ecx, [rcx]
	mov DWORD PTR[rdi+8], ecx
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
	ret

//int find(const char *s) const
.global _ZNK8mystring4findEPKc
_ZNK8mystring4findEPKc:
	ret

//const char *c_str() const
.global _ZNK8mystring5c_strEv
_ZNK8mystring5c_strEv:
	mov rax, [rdi]
	ret

//friend ostream &operator<<(...)
.global _ZlsRSoRK8mystring
_ZlsRSoRK8mystring:
	push rdi
	mov rsi, [rsi]
	call _ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc@plt
	pop rax
	ret

