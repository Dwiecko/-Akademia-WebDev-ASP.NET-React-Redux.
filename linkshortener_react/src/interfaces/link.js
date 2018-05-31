import PropTypes from 'prop-types';

const LinkInterface = PropTypes.shape ({
    Id: PropTypes.number.required,
    Hash: PropTypes.string.required,
    Url: PropTypes.string.required
});

export default LinkInterface;