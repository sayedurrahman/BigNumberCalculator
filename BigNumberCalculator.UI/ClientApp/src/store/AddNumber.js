const Add_Number = 'Add_Number';

let nextTodoId = 0;

export const addNumber = content => ({
    type: Add_Number,
    payload: content
});

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === Add_Number) {
        return {
            ...state,
            startDateIndex: action.startDateIndex,
            isLoading: true
        };
    }
    return state;
};