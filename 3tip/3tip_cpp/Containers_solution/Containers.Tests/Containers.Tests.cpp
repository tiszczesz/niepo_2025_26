#include "pch.h"
#include "CppUnitTest.h"
#include "../Containers.Console/Stack.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace ContainersTests
{
	TEST_CLASS(ContainersTests)
	{
	public:
		
		TEST_METHOD(IsEmptyOnStar)
		{
			Stack<int> stack;
			Assert::IsTrue(stack.isEmpty());
			stack.push(10);
			Assert::IsFalse(stack.isEmpty());	
		}
		TEST_METHOD(PushAndPop)
		{
			Stack<int> stack;
			stack.push(10);
			Assert::AreEqual(10, stack.pop());
		}
	};
}
