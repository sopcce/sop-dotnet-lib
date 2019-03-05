

namespace Sop.Common.Charts
{
    public interface IValue<TVlaueType>
    {
        TVlaueType Value { get; set; }
    }

    public interface ITopValue
    {
    }
    public interface ISymbolValue
    {
    }
    public interface IRightValue
    {
    }
    public interface INumberOrStringValue
    {
    }
    public interface INumberOrArrayNumberValue
    {
    }
    public interface ILeftValue
    {
    }
    public interface IBottomValue
    {
    }
}