﻿using Cargolator.API.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cargolator.Tests
{
    public class PointTests
    {
        [Fact]
        public void PointEqualsResult()
        {
            // Arrange
            Point a = new Point(5, 5);
            Point b = new Point(5, 5);

            // Act
            bool result = a.Equals(b);

            // Assert
            Assert.True(result);
        }
    }
}
