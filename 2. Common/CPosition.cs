namespace IntelligentFactory
{
    public class CPosition
    {
        public CPosition(string strAxis, string strName, long lPosition)
        {
            this.Axis = strAxis;
            this.Name = strName;
            this.Position = lPosition;
        }

        public CPosition()
        {
        }

        private string m_strAxis = "";

        public string Axis
        {
            get { return m_strAxis; }
            set { m_strAxis = value; }
        }

        private string m_strName = "";

        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        private long m_lPosition = 0;

        public long Position
        {
            get { return m_lPosition; }
            set { m_lPosition = value; }
        }
    }
}