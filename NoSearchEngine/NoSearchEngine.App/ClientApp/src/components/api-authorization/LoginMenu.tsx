import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';

interface IProps {

}

interface IState {
    isAuthenticated: boolean,
    userName: string | null
}

interface IPath {
    pathname: string,
    state: IPathState
}

interface IPathState {
    local: boolean
}

export class LoginMenu extends Component<IProps, IState> {
    private _subscription: number = 0;

    constructor(props: IProps) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {        
        const isAuthenticated = await authService.isAuthenticated();
        const user = await authService.getUser();

        console.log(isAuthenticated);
        console.log(user);

        this.setState({
            isAuthenticated,
            userName: user && user.name
        });                
    }

    render() {       
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath : IPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath);
        }
       
    }

    authenticatedView(userName: string | null, profilePath: string, logoutPath: IPath) {
        return (<Fragment>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={profilePath}>Hello {userName}</NavLink>
            </NavItem>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={logoutPath}>Logout</NavLink>
            </NavItem>
        </Fragment>);

    }

    anonymousView(registerPath: string, loginPath: string) {        

        return (<Fragment>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={registerPath}>Register</NavLink>
            </NavItem>
            <NavItem className="custom-nav">
                <NavLink tag={Link} className="text-dark" to={loginPath}>Login</NavLink>
            </NavItem>
        </Fragment>);        
    }
}
