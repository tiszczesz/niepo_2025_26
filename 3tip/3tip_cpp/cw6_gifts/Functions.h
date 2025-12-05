#pragma once
#include <vector>
#include "Gift.h"
std::vector<Gift*> GenerGifts();
void ClearGifts(std::vector<Gift*>& gifts);
void ShowGifts(const std::vector<Gift*>& gifts);
