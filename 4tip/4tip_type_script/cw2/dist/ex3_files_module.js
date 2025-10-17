export const countWords = (length, words) => {
    let result = 0;
    for (const word of words) {
        if (word.length === length) {
            result++;
        }
    }
    return result;
};
//# sourceMappingURL=ex3_files_module.js.map