import Item from './Item';

export default class Body extends React.Component {
    constructor() {
        super();
        this.state = {
      
        };
    }

    
    render() {
        var addRows = this.props.items.map(function (item) {
            return (
                <Item name={item.name} price={item.price} qty={item.qty} total={item.total} key={item.id} />
            );
        });
        return (
            <div>
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th className="text-center">QTY</th>
                            <th>الصنف</th>
                            <th>السعر</th>
                            <th>الكمية</th>
                            <th>المجموع</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {addRows}
                       {/*  <Item name="Nasir Taha" price="25.00" qty = "1" total="20" />
                        <Item name="Nasir Taha" price="25.00" qty = "1" total="20"/>
                        <Item name="Nasir Taha" price="25.00" qty = "1" total="20"/>
                       <tr>
                            <td colSpan="4">المجموع</td>
                            <td><strong>85.00</strong></td>
                        </tr>
                        <tr>
                            <td colSpan="4">الضريبة</td>
                            <td><strong>10</strong></td>
                        </tr>
                        <tr>
                            <td colSpan="4">المجموع شامل الضريبة</td>
                            <td><strong>95</strong></td>
                        </tr>*/}
                    </tbody>
                </table>
            </div>
            );
    }
}