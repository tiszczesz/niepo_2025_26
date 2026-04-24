#pragma once
template<typename T>
class Item {
public:
    T value;
    Item<T>* next;

    Item(const T& val) : value(val), next(nullptr) {}
};

