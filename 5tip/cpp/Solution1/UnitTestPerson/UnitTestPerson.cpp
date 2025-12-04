#include "pch.h"
#include "CppUnitTest.h"
#include "../ConsoleApplication1/ConsoleApplication1.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTestPerson
{
	TEST_CLASS(UnitTestPerson)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			Person p2("John", "Doe", -30);
			Assert::IsTrue(p2.GetAge() >= 0);
		}
		TEST_METHOD(IsFirstNameEmpty) {
			Person p2;
			std::string toTest = "";
			Assert::AreEqual(p2.GetFirstName().c_str(), "");
		}
	};
}
