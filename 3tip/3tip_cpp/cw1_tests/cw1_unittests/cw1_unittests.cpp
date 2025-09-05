#include "pch.h"
#include "CppUnitTest.h"
#include "../cw1_tests/Counter.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace cw1unittests
{
	TEST_CLASS(cw1unittests)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			Counter c1;
			Assert::AreEqual(0, c1.getCount());
		}
		TEST_METHOD(if_ctor_set_count) {
			Counter c1(5);
			Assert::AreEqual(5, c1.getCount());
		}
		TEST_METHOD(if_increment_increases_count) {
			Counter c1;
			c1.increment();
			Assert::AreEqual(1, c1.getCount());
		}
		TEST_METHOD(if_decrement_decreases_count) {
			Counter c1;
			c1.decrement();
			Assert::AreEqual(-1, c1.getCount());
		}
	};
}
