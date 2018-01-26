import { connect } from 'react-redux';
import ReactAutocomplete from 'react-autocomplete';

class Toolbar extends React.Component {
  
fakeRequest(value) {
    this.props.GelAllItems(value);
}
/*
    fakeRequest(value) {
       
        var url = "http://50.3.75.39/PosAPIv1/api/v1/Items";
        var xhr = new XMLHttpRequest();
        xhr.open('get', url, true);

        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ items: data });
        }.bind(this);
        xhr.send();
    }
*/
    render() {
        return (
<div className="widget-body-toolbar">

    <div className="row">

        <div className="col-sm-4">
                        <div className="input-group">
                            {this.props.toolBarData.selectedLabel}
                            {this.props.toolBarData.value}
                            <h5> Hi2</h5>
                            <ReactAutocomplete
                                items={this.props.toolBarData.items}
                                autoHighlight={true}
                                shouldItemRender={(item, value) => item.englishName.toLowerCase().indexOf(value.toLowerCase()) > -1}
                                getItemValue={item => item.englishName}
                                renderItem={(item, highlighted) =>
                                    <div
                                        key={item.id}
                                        style={{ backgroundColor: highlighted ? '#eee' : 'transparent' }}
                                    >
                                        {item.englishName}
                                    </div>
                                }
                                value={this.props.toolBarData.value}
                                //onChange={e => this.setState({ value: e.target.value })}
                                onChange={(event, value) => {
                                    this.props.onChange(value)
                                    clearTimeout(this.requestTimer)
                                    this.requestTimer = this.fakeRequest(value)
                                }}
                                onSelect={(value, item) => this.props.onSelect(value)}
                                menuStyle={{
                                    borderRadius: '3px',
                                    boxShadow: '0 2px 12px rgba(0, 0, 0, 0.1)',
                                    background: 'rgba(255, 255, 255, 0.9)',
                                    padding: '2px 0',
                                    fontSize: '90%',
                                    position: 'fixed',
                                    overflow: 'auto',
                                    maxHeight: '50%', // TODO: don't cheat, let it flow to the bottom
                                }}
                            />
                <div className="input-group-btn">
                    <button className="btn btn-default" type="button">
                        <i className="fa fa-search"></i> بحث
                    </button>
                </div>
              </div>   
          </div> 

          <div className="col-sm-8 text-align-right">
               <div className="btn-group">
                    <a href="javascript:void(0)" className="btn btn-sm btn-success"> <i className="fa fa-plus"></i> جديد </a>
               </div>
                <div className="btn-group">
                        <a href="javascript:void(0)" className="btn btn-sm btn-primary"> <i className="fa fa-edit"></i> رجوع </a>
                </div>
        </div>
    </div>
</div>
            );
    }
}

const mapStateToProps = (state) => {
    return {
            toolBarData: state.ToolbarReducer
        };
}
const mapDispatchToProps = (dispatch) => {
   return {
    GelAllItems: (value) => {
      dispatch({
            type: "SEARCH_ITEM",
            payload: value
        });
    },
onChange: (value) => {
      dispatch({
            type: "SET_VALUE",
            payload: value
        });
    },
onSelect: (value) => {
      dispatch({
            type: "ON_SELECT",
            payload: value
        });
    }
  };
}

export default connect(mapStateToProps, mapDispatchToProps )(Toolbar);