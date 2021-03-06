﻿namespace EnergyTrading.Mdm.Contracts.Test
{
    using System.Collections.Generic;

    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class SystemIdentifierFixture
    {
        [Test]
        public void ReturnNullIfEntityNull()
        {
            IMdmEntity value = null;

            var candidate = value.SystemIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnValueForEntityIfSystemFound()
        {
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());
            entity.Identifiers.Add(expected);

            var candidate = entity.SystemIdentifier("A");
            Assert.AreSame("A", candidate);
        }

        [Test]
        public void ReturnNullIfIdentifiersNull()
        {
            IList<MdmId> value = null;

            var candidate = value.SystemIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNullIfIdentifierCountZero()
        {
            var identifiers = new List<MdmId>();

            var candidate = identifiers.SystemIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnValueIfSystemFound()
        {
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.SystemIdentifier("A");
            Assert.AreSame("A", candidate);
        }

        [Test]
        public void ReturnNullIfSystemNotFound()
        {
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.SystemIdentifier("B");
            Assert.IsNull(candidate);
        }
    }
}