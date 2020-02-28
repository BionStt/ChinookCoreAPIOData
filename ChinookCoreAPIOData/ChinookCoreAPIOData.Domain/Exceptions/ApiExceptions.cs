﻿using System;

namespace ChinookCoreAPIOData.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException()
        {
        }

        public MethodNotAllowedException(string message)
            : base(message)
        {
        }

        public MethodNotAllowedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class NotExceptableException : Exception
    {
        public NotExceptableException()
        {
        }

        public NotExceptableException(string message)
            : base(message)
        {
        }

        public NotExceptableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class ConflictException : Exception
    {
        public ConflictException()
        {
        }

        public ConflictException(string message)
            : base(message)
        {
        }

        public ConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException()
        {
        }

        public UnprocessableEntityException(string message)
            : base(message)
        {
        }

        public UnprocessableEntityException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}