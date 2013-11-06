using UnityEngine;
using System.Collections;

public class Slot 
{

	private int row;
	private int col;
	
	public Slot (int row, int col)
	{
		this.row = row;
		this.col = col;
	}
	
	public int getRow ()
	{
		return this.row;
	}

	public int getCol ()
	{	
		return this.col;
	}
	
	public void setRowAndCol (int row, int col)
	{
		this.row = row;
		this.col = col;
	}


}
