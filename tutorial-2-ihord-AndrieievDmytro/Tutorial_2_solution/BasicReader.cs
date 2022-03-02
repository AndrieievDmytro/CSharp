public abstract class BasicReader<T> : IReader<T>
{
    protected readonly ILogger _logger;
    protected readonly Utils _utils;
    public BasicReader(ILogger logger, Utils utils )
    {
        _logger = logger;
        _utils = utils;
    }
    public virtual T Read (string path) 
    {
        _utils.isCorrectPass(path);
        _utils.isExists(path);
        return default(T);
    }
}