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


	return 0;
}
