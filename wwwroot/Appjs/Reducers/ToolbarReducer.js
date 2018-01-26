function ToolbarReducer(state = {
                                    items: [],
                                    value: '',
                                    selectedLabel: '',

                                }, action) {
    switch (action.type) {
        case "SEARCH_ITEM":
            state = {...state, items : [{
                                        id : 0,
                                        englishName : "Item0"
                                    },
                                    {
                                        id : 1,
                                        englishName : "Item1"
                                    }] 
                    }       
             break;

         case "ADD_TO_INVOICE":
                    state = {...state, name : action.payload }       
                     break;
         case "SET_VALUE":
                    state = {
                        ...state, 
                        value : action.payload,
                        selectedLabel : action.payload
                 }       
                     break;
            case "ON_SELECT":
                    state = {
                        ...state, 
                        value : action.payload,
                 }       
                     break;
    }
    return state;
}
export default ToolbarReducer;