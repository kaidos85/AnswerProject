import React, { Component } from 'react';
import { Button } from 'reactstrap';
import QuestionDialog from './QuestionDialog';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            answers: [],
            loading: true,
            open: false,
        };
    }

    componentDidMount() {
        this.populateAnswersData();
    }

    handleClickOpen = () => {
        this.setState({ open: true });
        this.refs.child.populateQuestionsData();
    };

    handleClose = (value) => {
        this.setState({ open: false });
        if (value) {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(value)
            };
            fetch('api/answer', requestOptions)
                .then(response => {
                    this.populateAnswersData();
                    alert('Success');
                })
                .catch(error => alert('Error'));
        }
    };

    static renderAnswersTable(answers) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>UserName</th>
                        <th>Date</th>
                    </tr>
                </thead>
                <tbody>
                    {answers.map(answer =>
                        <tr key={answer.date}>
                            <td>{answer.userName}</td>
                            <td>{answer.aDate}</td>                            
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render () {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderAnswersTable(this.state.answers);

        return (
            <div>                
                <h1 id="tabelLabel">Answers</h1>
                <Button variant="outlined" color="primary" onClick={this.handleClickOpen}>
                    Add answers
                </Button>
                <QuestionDialog ref="child" open={this.state.open} values={this.state.answers} onClose={this.handleClose} />
                {contents}
            </div>
        );
    }

    async populateAnswersData() {
        const response = await fetch('api/answer');
        const data = await response.json();
        this.setState({ answers: data, loading: false });
    }
}
