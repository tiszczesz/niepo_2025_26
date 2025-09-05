#pragma once
class Counter
{
public:
	Counter():count(0){}
	//Counter() {
	//	count = 0;
	//}
	Counter(int c) :count(c) {}
	int getCount() {
		return count;
	}
	void increment() {
		count++;
	}
	void decrement() {
		count--;
	}
	
private:
	int count;
};

