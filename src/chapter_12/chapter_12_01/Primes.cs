using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace chapter_12_01
{
	public class Primes : IEnumerable<long>
	{
		public Primes(long Max = long.MaxValue)
		{
			this.Max = Max;
		}

		public long Max { get; private set; }

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<long>)this).GetEnumerator();

		public IEnumerator<long> GetEnumerator()
		{
			yield return 1;
			bool bFlag;
			long start = 2;
			while (start < Max)
			{
				bFlag = false;
				var number = start;
				for (int i = 2; i < number; i++)
				{
					if (number % i == 0)
					{
						bFlag = true;
						break;
					}
				}

				if (!bFlag)
				{
					yield return number;
				}
				start++;
			}
		}

	}
}
