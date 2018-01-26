#include <stdio.h>

struct Stack {
	int *data;
};

struct Node {
	int value;
	struct Node *left;
	struct Node *right;
};


/* Fibonacci */
long FibRecur(short n);
long FibTail(short n);

/* Stack */
void Push(struct Stack *s, int value);
int Pop(struct Stack *s);

/* Tree */
struct Node *Insert(struct Node *root, int value);
struct Node *Search(struct Node *root, int search_value);
void PrintTree(struct Node *root);


int
main(int argc, char** argv)
{
	printf("size of long: %ld\n", FibRecur(7));

	return 0;
}
/*
long
FibRecur(short n)
{
	if( n <= 1 )
		return 1L;
	return FibRecur(n - 1) + FibRecur(n-2);
}
*/
