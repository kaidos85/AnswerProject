import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogTitle from '@material-ui/core/DialogTitle';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import InputComp from './InputComp';

export default class QuestionDialog extends Component {

    constructor(props) {
        super(props);
        this.state = { questions: [], num: 0, loading: false, disabled: true };
    }

    render() {
        const { onClose, open } = this.props;

        const handleSave = () => {
            onClose(this.state.questions);
        };

        const handleClose = () => {
            onClose(false);
        };

        const count = () => {
            return this.state.questions ? this.state.questions.length : null;
        }

        const handlePrev = () => {
            if (this.state.num === 0) {
                this.setState({ num: count() - 1 });
            }
            else {
                this.setState({ num: this.state.num - 1 });
            }
        }

        const handleNext = () => {
            if (this.state.num + 1 < count()) {
                this.setState({ num: this.state.num + 1 });
            }
            else {
                this.setState({ num: 0 });
            }
        }

        const onChangeValue = (value) => {
            this.setState(state => {
                state.questions[this.state.num].value = value;
                return {
                    questions: state.questions,
                    disabled: state.questions.filter(c => c.value === '').length > 0,
                    num: state.num,
                    loading: state.loading
                }
            });
        }

        const questionItem = () =>{
            return this.state.questions[this.state.num]
        }

        return (
            this.state.loading &&
            <Dialog onClose={handleClose} aria-labelledby="simple-dialog-title"
                open={open}
                disableBackdropClick={true}>
                    <DialogTitle id="simple-dialog-title">Вопрос {this.state.num + 1} из {count()}</DialogTitle>
                    <DialogContent>
                    <span>{questionItem().questionText}: </span>
                    <InputComp value={questionItem().value}
                        type={questionItem().dataType}
                        enumeration={questionItem().enumeration}
                        onChangeValue={onChangeValue} />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={handlePrev}>
                            Назад
                    </Button>
                        <Button onClick={handleNext}>
                            Вперед
                    </Button>
                    <Button onClick={handleSave} color="primary" disabled={this.state.disabled} >
                            Отправить
                    </Button>
                        <Button onClick={handleClose} color="secondary">
                            Отмена
                    </Button>
                    </DialogActions>
                </Dialog>            
        );
    }

    async populateQuestionsData() {
        const response = await fetch('api/question');
        const data = await response.json();
        const mapData = data.map(d =>
        {
            return {
                question_Id: d.id,
                questionText: d.text,
                dataType: d.dataType,
                value: '',
                enumeration: d.enumeration
            };
        })
        this.setState({ questions: mapData, num: 0, loading: true });
    }
}