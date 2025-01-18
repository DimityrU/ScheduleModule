class BaseProxy {
    constructor(token = null) {
        this.token = token;
        this.config = {};
    }

    async loadConfig() {
        try {
        const response = await fetch('../../../rest-config.json');
        const config = await response.json();
        this.config = config;
        } catch (error) {
        console.error("Error loading config:", error);
        }
    }

    getHeaders() {
        const headers = {
        'Content-Type': 'application/json',
        };
        if (this.token) {
        headers['Authorization'] = `Bearer ${this.token}`;
        }
        return headers;
    }

    addParams(endpoint, params) {
        let url = endpoint;
    
        if (params) {
          for (const [key, value] of Object.entries(params)) {
            url = url.replace(`:${key}`, value);
          }
        }
    
        return url;
      }

    async get(endpointKey, params = {}) {
        try {
        let endpoint = this.config.ENDPOINTS[endpointKey];

        if(params) {
            endpoint = this.addParams(endpoint, params)
        }
        const response = await fetch(`${this.config.BASE_URL}${endpoint}`, {
            method: 'GET',
            headers: this.getHeaders(),
        });
        return this.handleResponse(response);
        } catch (error) {
        console.error('Error during GET request:', error);
        }
    }

    async post(endpointKey, data) {
        try {
        const endpoint = this.config.ENDPOINTS[endpointKey];
        const response = await fetch(`${this.config.BASE_URL}${endpoint}`, {
            method: 'POST',
            headers: this.getHeaders(),
            body: JSON.stringify(data),
        });
        return this.handleResponse(response);
        } catch (error) {
        console.error('Error during POST request:', error);
        }
    }

    async put(endpointKey, data) {
        try {
        const endpoint = this.config.ENDPOINTS[endpointKey];
        const response = await fetch(`${this.config.BASE_URL}${endpoint}`, {
            method: 'PUT',
            headers: this.getHeaders(),
            body: JSON.stringify(data),
        });
        return this.handleResponse(response);
        } catch (error) {
        console.error('Error during PUT request:', error);
        }
    }

    async delete(endpointKey, params = {}) {
        try {
        let endpoint = this.config.ENDPOINTS[endpointKey];

        if(params) {
            endpoint = this.addParams(endpoint, params)
        }

        const response = await fetch(`${this.config.BASE_URL}${endpoint}`, {
            method: 'DELETE',
            headers: this.getHeaders(),
        });
        return this.handleResponse(response);
        } catch (error) {
        console.error('Error during DELETE request:', error);
        }
    }

    async handleResponse(response) {
        const data = await response.json();
        if (data.hasError) {
            alert(`API Error: ${data.errorMessage}`);
            throw new Error(data.errorMessage || 'Something went wrong!');
        }
        return data;
    }   
}

export default BaseProxy;
