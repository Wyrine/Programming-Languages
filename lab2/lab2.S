.intel_synax noprefix

.section .text

//~mystring()
.global _ZN8mystringD1Ev
_ZN8mystringD1Ev:
	ret

//mystring()
.global _ZN8mystringC1Ev
_ZN8mystringC1Ev:
	ret

//mystring(const char *s)
.global _ZN8mystringC1EPKc
_ZN8mystringC1EPKc:
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
	ret

//friend ostream &operator<<(...)
.global _ZlsRSoRK8mystring
_ZlsRSoRK8mystring:
	ret
