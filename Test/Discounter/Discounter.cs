namespace Test.Discounter
{
    public abstract class Discounter

    {
        #region Properties

        // user protected readonly 
        protected Projector Projector;
        #endregion

        #region Constructor
        protected Discounter(Projector projector)
        {
            // handle null reference exception on projector variable.
             Projector = projector;
        }
        #endregion
    }
}