#pragma once
#include "Container.h"
#include "Item.h"
#include <stdexcept>

template<typename T>
class Stack : public Container<T> {
private:
    Item<T>* topNode;   

public:
    Stack() : topNode(nullptr), Container<T>() {}

    void push(const T& item) override {
        Item<T>* newItem = new Item<T>(item);
        newItem->next = topNode;
        topNode = newItem;
        this->size++;
    }
    int GetSize() override {
        return this->size;
    }

    T pop() override {
        if (isEmpty()) throw std::underflow_error("Stack is empty.");
        T item = topNode->value;
        Item<T>* temp = topNode;
        topNode = topNode->next;
        delete temp;
        return item;
    }

    T top() const override {
        if (isEmpty()) throw std::underflow_error("Stack is empty.");
        return topNode->value;
    }

    bool isEmpty() const override {
        return topNode == nullptr;
    }

    ~Stack() {
        while (!isEmpty()) {
            pop();
        }
    }
};

