namespace DesignPatterns.Interfaces {
  public interface IReconObjectFactory
    {
        IReconcile GetReconObject(string ReconType);
    }
}