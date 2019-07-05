namespace MyTest
{

    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class AttributeTestAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string className;
        public double version;
        
        // This is a positional argument
        public AttributeTestAttribute(string className, double version = 1.0)
        {
            this.className = className;
            this.version = version;
            // TODO: Implement code here
            // throw new System.NotImplementedException();
        }
        
        public string ClassName
        {
            get { return className; }
        }
        
        public double Version
        {
            get {return version; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    sealed class AttributeTestAttributeMethod : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string className;
        public double version;
        
        // This is a positional argument
        public AttributeTestAttributeMethod(string className, double version = 1.0)
        {
            this.className = className;
            this.version = version;
            // TODO: Implement code here
            // throw new System.NotImplementedException();
        }
        
        public string ClassName
        {
            get { return className; }
        }
        
        public double Version
        {
            get {return version; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}