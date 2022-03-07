import React, {Component} from "react";

const controllerUrl = "/departments/";

export class Departments extends Component{
    constructor(props){
        super(props);
        this.state = {departments:[], loading:true};
    }

    componentDidMount(){
        this.populateDepartmentsData();
    }

    static renderDepartments(departments){
        return(
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {departments.map(department =>
                        <tr key={department.id}>
                            <td>{department.id}</td>
                            <td>{department.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }

    render(){
        let contents = this.state.loading? <p><em>The data is loading, please wait</em></p> : Departments.renderDepartments(this.state.departments)
        return contents;
    }

    async populateDepartmentsData(){
        const response = await fetch('https://localhost:7049/api' + controllerUrl + "getdepartments");
        const data = await response.json();
        this.setState({departments: data, loading:false})
    }
}