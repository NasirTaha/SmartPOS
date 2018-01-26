import { connect } from 'react-redux';

 class Item extends React.Component {
    constructor() {
        super();
    }

    
    render() {
        return (
            <tr>
                <td className="text-center"><strong>1</strong></td>
                <td><a href="javascript:void(0);">{this.props.name}</a></td>
                <td>{this.props.price}</td>
                <td>{this.props.qty}</td>
                <td>{this.props.total}</td>
                <td>{this.props.sale.name} </td>
            </tr>
        );
    }
}
const mapStateToProps = (state) => {
    return {
            sale: state.SaleInvoiceReducer
        };
}
const mapDispatchToProps = (state) => {
   return {
    onTodoClick: () => {
      dispatch({
            type: "SEARCH_ITEM",
            payload: "hi"
        });
    }
  };
}

export default connect(mapStateToProps, mapDispatchToProps )(Item);