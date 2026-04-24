#pragma once
template<typename T>
class Container {
    protected:
        int size;

public:
	Container():size(0) {  }
    virtual void push(const T& item) = 0;
    virtual T pop() = 0;
    virtual T top() const = 0;
    virtual bool isEmpty() const = 0;
    virtual ~Container() {}
    virtual int GetSize() = 0;
};
