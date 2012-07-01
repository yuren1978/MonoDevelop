//TODO:http://www.mitbbs.com/article_t/JobHunting/32113255.html
using System;
using System.Collections.Generic;

public class Node
{
	public int value;
	public Node left;
	public Node right;	
}



class TreeByLevel
{
	static Node CreateTree(int[] array, int start, int end)
	{
		if(start<=end){
			int middle=(start+end)/2;
			Node node=new Node();
			node.value=array[middle];
			node.left=CreateTree(array, start, middle-1);
			node.right=CreateTree(array, middle+1, end);
			return node;
		}
		else {
			return null;
		}
	}

	static void PrintNode(Node root){
		Console.Write(root.value+" ");
	}

	static void ZigZapByLevel(Node root){
		if(root==null)
				return;
			bool leftToRight=true;
			List<Node> list=new List<Node>();
			Queue<Node> queue=new Queue<Node>();
			queue.Enqueue(root);
			int currentLevelNode=1;
			int nextLevelNode=0;
			
			while(queue.Count>0){
				Node current=queue.Dequeue();
				currentLevelNode--;	
					
				if(current!=null){
					list.Add(current); 
					queue.Enqueue(current.left);
					queue.Enqueue(current.right);
					nextLevelNode+=2;
				}
				
				if(currentLevelNode==0){
					if(leftToRight){//left to right
						leftToRight=false;
					}
					else {
						list.Reverse();
						leftToRight=true;
					}
					list.ForEach(PrintNode);
					list.Clear();
					Console.WriteLine(" ");
					currentLevelNode=nextLevelNode;
					nextLevelNode=0;
				}
			}	
	}

	static void BFSPrintTreeByLevel(Node root){
		if(root==null)
			return;
			
		Queue<Node> queue=new Queue<Node>();
		queue.Enqueue(root);
		int currentLevelNode=1;
		int nextLevelNode=0;
		
		while(queue.Count>0){
			Node current=queue.Dequeue();
			currentLevelNode--;	
				
			if(current!=null){
				Console.Write(current.value+" ");
				queue.Enqueue(current.left);
				queue.Enqueue(current.right);
				nextLevelNode+=2;
			}
			
			if(currentLevelNode==0){
				Console.WriteLine("");
				currentLevelNode=nextLevelNode;
				nextLevelNode=0;
			}
		}	
	}


	static void Main()
	{
		int[] a={1,2,3,4,5,6,7,8,9};
		Node root=CreateTree(a,0, a.Length-1);
		Console.WriteLine("Print Tree By Level");
		BFSPrintTreeByLevel(root);
		ZigZapByLevel(root);
		
	}
}