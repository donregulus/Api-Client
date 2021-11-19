namespace rfeTestAPI.Models
{
    public class Diff
    {
        public Diff(string left, string right, string id)
        {
            Left  = left  ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
            Id    = id    ?? throw new ArgumentNullException(nameof(id));
        }

        public string ComputeDiff()
        {
            string ret ;
            if (this.Left == this.Right)
            {
                ret = "Inputs were Equals";
            }
            else if (this.Left.Length != this.Right.Length)
            {
                ret = "Inputs are of diferent size";
            }
            else
            {
                ret = "Compute offset and length";
            }
            return ret;        
        }

        public string Left  { set; get; }
        public string Right { set;get; }
        public string Id       { set; get; }
    }
}
