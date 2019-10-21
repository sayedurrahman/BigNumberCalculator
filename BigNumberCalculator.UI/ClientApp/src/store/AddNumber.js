const Add_Number = 'Add_Number';

let nextTodoId = 0;

export const addNumber = content => ({
    type: Add_Number,
    payload: {
        id: ++nextTodoId,
        content
    }
});

