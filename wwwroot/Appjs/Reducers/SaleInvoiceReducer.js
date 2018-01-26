function SaleInvoiceReducer(state = {age: 35,  name: "default name"}, action) {
    switch (action.type) {
        case "SEARCH_ITEM":
            state = {...state, name : action.payload }       
             break;
    }
    return state;
}
export default SaleInvoiceReducer;