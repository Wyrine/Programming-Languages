interface ICompValue : System.IComparable
{
     /// System.IComparable.CompareTo(object)
     /// Needs to:
     /// return -1 if this.Val < object.Val (object typecasted into ICompValue)
     /// return 0 if this.Val == object.Val (object typecasted into ICompValue)
     /// return 1 if this.Val > object.Val

     /// Raw property (gets/sets the RAW DPD or BCD)
     uint Raw { get; set; }
     /// Decoded property (gets the actual number)
     uint Val { get; }
}
