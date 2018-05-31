import React from 'react';

import { CFG_HTTP } from '../cfg/cfg_http';
import { UtilsApi } from '../utils/utils_api';
import Pagination from '../components/Pagination';
import LinksTable from '../components/LinksTable';

class LinksContainer extends React.Component {
    handlePageChange = (pageNumber) => {
        this.fetchLinks(pageNumber);
    };

    fetchLinks = (currentPage = 0) => {
        let dataFromApi = {page: currentPage};

        UtilsApi
            .get(CFG_HTTP.URL_LINKS, dataFromApi)
            .then((links) => {
                this.setState({
                    links: links.items,
                    pagesLimit: links.pageInfo.maxPage,
                    currentPage: links.pageInfo.currentPage
                });
            });
    };


    componentDidMount() {
        this.fetchLinks();
    }

    constructor() {
        super();

        this.state = {
            links: [],
            pagesLimit: 1,
            currentPage: 0
        };
    }

    render () {
        return (
            <React.Fragment>
                <Pagination currentPage = {this.state.currentPage}
                            pagesLimit = {this.state.pagesLimit}
                            onPageChange = {this.handlePageChange} />
                <LinksTable links={this.state.links} />
            </React.Fragment>
        );
    }
};

export default LinksContainer;