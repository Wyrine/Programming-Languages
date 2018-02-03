.intel_synax noprefix

.section .rodata
empt: .asciz ""

.section .text

//~mystring()
.global _ZN8mystringD1Ev
_ZN8mystringD1Ev:
	mov	QWORD PTR[rdi+8], 0
	cmp QWORD PTR[rdi], 0
	je 1f
	mov rdi, [rdi]
	call _Zd1Pv@plt
1:
	ret

//mystring()
.global _ZN8mystringC1Ev
_ZN8mystringC1Ev:
	mov QWORD PTR[rdi], 0
	mov DWORD PTR[rdi+8], 0
	ret

//mystring(const char *s)
.global _ZN8mystringC1EPKc
_ZN8mystringC1EPKc:
	push rdi
	push rsi
	mov rdi, rsi
	
	call strdup@plt
	
	pop rsi
	pop rdi

	mov [rdi], rax
	
	push rdi
	mov rdi, rax
	
	call strlen@plt
	
	pop rdi
	mov [rdi+8], eax
	ret

//mystring(const mystring &rhs)
.global _ZN8mystringC1ERKS_
_ZN8mystringC1ERKS_:
	ret

//mystring &operator=(const char *s)
.global _ZN8mystringaSEPKc
_ZN8mystringaSEPKc:
	ret

//mystring &operator=(const mystring &&rhs)
.global _ZN8mystringaSEOKS_
_ZN8mystringaSEOKS_:
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
	ret
