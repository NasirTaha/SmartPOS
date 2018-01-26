import ReactAutocomplete  from 'react-autocomplete';

export default class CommentForm extends React.Component {
    constructor() {
        super();

        this.state = {
            author: '', 
            text: '',
            items: [],
            selectedLabel : ''
        };
    }

    handleAuthorChange(e){
        this.setState({ author: e.target.value });
    }

    handleTextChange(e){
        this.setState({ text: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        var author = this.state.author.trim();
        var text = this.state.text.trim();
        if (!text || !author) {
            return;
        }
        // TODO: send request to the server
        this.props.onCommentSubmit({ author: author, text: text });
        this.setState({ author: '', text: '' });
    }
    fakeRequest(value) {
        var xhr = new XMLHttpRequest();
        xhr.open('get', "/search?query=" + value, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ items: data });
        }.bind(this);
        xhr.send();
    }

    render() {
        return (
            <div>
           
           
                <br />
                <label> {this.state.selectedLabel}</label>
            <ReactAutocomplete
                    items={this.state.items}
                    autoHighlight={true}
                    value = 'please'
                    shouldItemRender={(item, value) => item.label.toLowerCase().indexOf(value.toLowerCase()) > -1}
                    getItemValue={item => item.label}
                    renderItem={(item, highlighted) =>
                        <div
                            key={item.id}
                            style={{ backgroundColor: highlighted ? '#eee' : 'transparent' }}
                        >
                            {item.label}
                        </div>
                    }
                    value={this.state.value}
                    //onChange={e => this.setState({ value: e.target.value })}
                    onChange={(event, value) => {
                        this.setState({ value })
                        clearTimeout(this.requestTimer)
                        this.requestTimer = this.fakeRequest(value)
                    }}
                    onSelect={ (value, item) => this.setState({ 'selectedLabel': value })}
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
            <br />
            <br />
            <form className="commentForm" onSubmit={this.handleSubmit.bind(this)}>
                <input
                    type="text"
                    placeholder="Your name"
                    value={this.state.author}
                    onChange={this.handleAuthorChange.bind(this)}

                />
                <input
                    type="text"
                    placeholder="Say something..."
                    value={this.state.text}
                    onChange={this.handleTextChange.bind(this)}
                />

               

                <input type="submit" value="Post" />
            </form>
            </div>
        );
    }
}