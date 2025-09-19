namespace Module01.Lesson06.ClassLibrary
{
    public enum SupervisoryLevel
    {
        /// <summary>
        /// enum names are named value (strings) representing an integer value
        /// by default the integer values start at 0 and increment by one
        /// you can assigned your own integer:  stringName = 15
        /// values can be negative: unknown = -1
        /// </summary>
        ///  
        Entry,              //0
        TeamMember,         //1
        TeamLeader,         //2
        Supervisor,         //3
        DepartmentHead,     //4
        Owner               //5
    }
}
