import React, { Component } from 'react';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import Checkbox from '@material-ui/core/Checkbox';

export default class InputComp extends Component {

    render() {
        const { value, type, onChangeValue, enumeration } = this.props;
        const handleChange = (event) => {
            if (type === 'checkbox') {                
                if (value === '' || value === 'false') {
                    onChangeValue('true');
                }
                else {
                    onChangeValue('false');
                }   
            }
            else {
                onChangeValue(event.target.value); 
            }
                       
        }
        if (type === 'enum') {
            return (
                <Select labelId="demo-simple-select-disabled-label"
                    id="demo-simple-select-disabled"
                    value={value}
                    onChange={handleChange}>
                    {enumeration.map(v =>
                        <MenuItem value={v} key={v}>{v}</MenuItem>
                    )}
                    </Select>
                );
        }
        if (type === 'checkbox') {
            return (
                <Checkbox checked={value === 'true'} onChange={handleChange}  />
                );
        }
        return (
            <input type={type} value={value} onChange={handleChange} />
        );
    }
}