
using IField;
using McDriod;

namespace Farm
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Cow cow = new Cow();
            McDriod.Pig McPig = new McDriod.Pig();

            Sheep sheep = new Sheep();
            IField.Pig IPig = new IField.Pig();
            
        }
    }
}


namespace IField
{
    public class Sheep { }
    public class Pig { }
}

namespace McDriod
{
    public class Cow { }
    public class Pig { }
}
