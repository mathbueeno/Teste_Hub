namespace Teste_Hub.Interface
{
	public interface IRange<T> where T : IComparable<T>
	{
		T Inicio { get; }
		T Fim { get; }
		bool IsValid { get; }
		bool Includes(T value);
		bool Includes(IRange<T> range);
		bool Overlaps(IRange<T> range);
	}



}
